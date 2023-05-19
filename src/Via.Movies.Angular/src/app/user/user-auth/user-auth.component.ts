import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.css']
})
export class UserAuthComponent implements OnInit {
@Output() onModalClose: EventEmitter<any> = new EventEmitter<any>();
currentTab: number = 0;

  constructor() { }

  ngOnInit(): void {
  }



}
