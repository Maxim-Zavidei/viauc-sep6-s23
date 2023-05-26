import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie-card/movie';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from '../services/movie.service';
import { StarService } from '../services/star.service';

@Component({
  selector: 'app-movie-info-page',
  templateUrl: './movie-info-page.component.html',
  styleUrls: ['./movie-info-page.component.css']
})
export class MovieInfoPageComponent implements OnInit {
movie: Movie | undefined;
moviePoster: any;
movieStars: any;
movieId: number = 0;
  constructor(private route: ActivatedRoute, private movieService: MovieService, private starService: StarService) {
   
   }

  ngOnInit(): void {
    this.movieId = Number(this.route.snapshot.paramMap.get('id'));
    this.movieService.getMovie(this.movieId).subscribe((movieData) => {
      this.movie = movieData;
      this.movieService.getMoviePoster(this.movie?.title).subscribe((posterData) => {
        this.moviePoster = posterData.results[0].poster_path;
        if (this.movieId > 0) {
          this.moviePoster = 'https://image.tmdb.org/t/p/w500' + this.moviePoster;
        }else {
          this.moviePoster = 'https://via.placeholder.com/150';
        }
        this.starService.getStarsForMovie(this.movieId).subscribe((starData) => {
          this.movieStars = starData;
        });
      });
    });
  }
}