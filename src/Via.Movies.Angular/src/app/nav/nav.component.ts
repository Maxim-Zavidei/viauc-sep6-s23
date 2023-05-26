import { isPlatformBrowser } from '@angular/common';
import { Component, EventEmitter, Inject, OnInit, Output, PLATFORM_ID } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Output() onSearchFieldChanged: EventEmitter<any> = new EventEmitter<any>();
  @Output() onLoginModalVisibleChanged: EventEmitter<any> = new EventEmitter<any>();
  userEmail: any = '';

  constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

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
		if (isPlatformBrowser(this.platformId)) {
			window.location.reload();
		}
  }

}
