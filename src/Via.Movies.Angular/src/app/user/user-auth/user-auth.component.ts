import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-user-auth',
  templateUrl: './user-auth.component.html',
  styleUrls: ['./user-auth.component.css']
})
export class UserAuthComponent implements OnInit {
@Output() onModalClose: EventEmitter<any> = new EventEmitter<any>();
currentTab: number = 0;

  constructor(private route: ActivatedRoute) {
    
  }

  ngOnInit(): void {
    this.route.url.subscribe(url => {
      this.currentTab = url[0].path === 'login' ? 0 : 1;
    });
  }



}
