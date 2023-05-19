import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAuthComponent } from './user-auth/user-auth.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    UserAuthComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    UserAuthComponent
  ]
})
export class UserModule { }
