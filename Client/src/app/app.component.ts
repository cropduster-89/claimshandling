import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { LossTypeService } from './services/loss-type.service';
import { LossType } from './models/loss-type.model';

@Component({
  	selector: 'app-root',
  	templateUrl: './app.component.html',
  	styleUrls: ['./app.component.scss']
})
export class AppComponent {
  	public title = 'Client';
  	public isAuthenticated = false;
  	public lossTypes: LossType[];
  	public username: string;
  	public password: string;

  	constructor(
  		private readonly authService: AuthService,
  		private readonly lossTypeService: LossTypeService
  	) { }

  	public login(): void {
  		this.authService.login(this.username, this.password)
  			.subscribe((result) => {
  				this.isAuthenticated = result;
  				if (this.isAuthenticated) {
  					this.getLossTypes();
  				}
  			});
  	}

  	public getLossTypes(): void {
  		this.lossTypeService.getPage(30, 0)
  			.subscribe((result) => this.lossTypes = result.pageData);
  	}

  	public logout(): void {
  		this.isAuthenticated = false;
  	}
}
