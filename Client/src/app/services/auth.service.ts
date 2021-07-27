import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  	providedIn: 'root'
})
export class AuthService {

  	constructor(private readonly http: HttpClient) { }

  	public login(username: string, password: string): Observable<boolean> {
  		return this.http.post<boolean>(environment.apiUrl + '/api/Authentication',
            { username: username, password: password })
  			.pipe(
  				map(() => true),
  				catchError(() => of(false))
			);
  	}
}
