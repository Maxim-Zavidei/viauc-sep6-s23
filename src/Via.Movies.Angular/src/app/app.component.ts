import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { NavComponent } from './nav/nav.component';
import { MovieService } from './services/movie.service';
import { debounceTime } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

	@Output() onSearchFieldChanged: EventEmitter<any> = new EventEmitter<any>();
  @Output() onLoginModalVisibleChanged: EventEmitter<any> = new EventEmitter<any>();
	@ViewChild('nav', {static: false}) nav: NavComponent | undefined;

	title = 'Snoozeflix';
  userEmail: any = '';
	loginModalVisible = false;
	searchText = '';
	cachedList: any[] = [];
	movies: any[] = [];

	constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.loginStatusChanged();
  }

	findMovie(searchText: string) {
		debounceTime(700);

    this.searchText = searchText;
    if (searchText === '') {
      this.cachedList = this.movies;
    }
    else {
			this.cachedList = []
			if (searchText.length > 3)
			{
				this.movieService.searchForMovies(searchText).subscribe((data: any[]) => {
					this.cachedList = data;
				});
			}
    }
  }

	loginStatusChanged() {
    this.loginModalVisible = false;
    if (this.nav)
    this.nav.loginStatusChanged();
  }
}
