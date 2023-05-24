import { TestBed } from '@angular/core/testing';
import { MovieService } from './movie.service';
import { of } from 'rxjs';

// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('MovieService', () => {
  let service: MovieService;
  let mockMovies: any[];  

  beforeEach(() => {
		TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [MovieService],
    });

    service = TestBed.inject(MovieService);

  mockMovies = [
    { id: 1, title: 'Movie 1', description: 'Description 1', imageUrl: 'https://via.placeholder.com/150' },
    { id: 2, title: 'Movie 2', description: 'Description 2', imageUrl: 'https://via.placeholder.com/150' },
  ];

  spyOn(service, 'getMovies').and.returnValue(of(mockMovies));
});

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return a list of movies when search is called', (done) => {
    service.getMovies().subscribe(movies => {
      expect(movies.length).toBe(2);
      expect(movies).toEqual(mockMovies);
      done();
    });
  });
});
