import { Component, EventEmitter, OnInit, Output, Inject, PLATFORM_ID} from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.css']
})
export class UserAuthComponent implements OnInit {
@Output() onModalClose: EventEmitter<any> = new EventEmitter<any>();
@Output() onLoginStatusChanged: EventEmitter<any> = new EventEmitter<any>();
currentTab: number = 0;


loginData: any = {
  email: '',
  password: ''
}

registerData: any = {
  name: '',
  email: '',
  password: '',
  confirmPassword: '',
  age: '',
  phoneNumber: ''
}

  constructor(private authenticationService: AuthenticationService, @Inject(PLATFORM_ID) private platformId: Object) {

  }

  ngOnInit(): void {

  }

  fieldChanged(formName: string ,fieldName: string, event: any) {
    if (formName === 'login')
      this.loginData[fieldName] = event.target.value;
    else
      this.registerData[fieldName] = event.target.value;
  }

submitRegister() {
  this.authenticationService.register(this.registerData.email, this.registerData.password, this.registerData.confirmPassword).subscribe((data) => {
    console.log(data);
		this.currentTab = 0;
  })
}

submitLogin() {
  this.authenticationService.login(this.loginData.email, this.loginData.password).subscribe((data) => {
    console.log(data);
    localStorage.setItem('email', this.loginData.email);
    localStorage.setItem('id', data.id);
    this.onModalClose.emit(true);
    this.onLoginStatusChanged.emit(true);
    if (isPlatformBrowser(this.platformId)) {
			window.location.reload();
		}
  })

}
}
