import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Output() onSearchFieldChanged: EventEmitter<any> = new EventEmitter<any>();
  @Output() onLoginModalVisibleChanged: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }

  searchFieldChanged(event: any) {
    this.onSearchFieldChanged.emit(event.target.value);
  }

  
}
