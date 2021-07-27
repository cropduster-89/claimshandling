import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PaginatedResult } from '../models/paginated-result.model';
import { LossType } from '../models/loss-type.model';
import { environment } from '../../environments/environment';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LossTypeService {

  constructor(private readonly http: HttpClient) { }

  public getPage(pageSize: number, pageIndex: string): Observable<PaginatedResult<LossType>> {
  		return this.http.get<PaginatedResult<LossType>>(environment.apiUrl + `/api/LossType?pageSize=${pageSize}&pageIndex=${pageIndex}`)
  			.pipe(
  				catchError(() => of(new PaginatedResult<LossType>()))
			);
  	}
}
