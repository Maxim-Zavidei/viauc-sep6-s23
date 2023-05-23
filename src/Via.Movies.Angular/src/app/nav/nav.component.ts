import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Output() onSearchFieldChanged: EventEmitter<any> = new EventEmitter<any>();
  @Output() onLoginModalVisibleChanged: EventEmitter<any> = new EventEmitter<any>();
  userEmail: any = '';

  constructor() { }

  ngOnInit(): void {
    this.loginStatusChanged();
  }

  searchFieldChanged(event: any) {
    this.onSearchFieldChanged.emit(event.target.value);
  }

  public loginStatusChanged() {
    console.log('login status changed');
    localStorage.getItem('email') ? this.userEmail = localStorage.getItem('email') : this.userEmail = '';

  }

  logout() {
    localStorage.clear();
    this.loginStatusChanged();
    alert('Logged out successfully');
  }
  
}
