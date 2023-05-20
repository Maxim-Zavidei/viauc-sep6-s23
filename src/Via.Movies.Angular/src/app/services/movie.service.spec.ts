import { TestBed } from '@angular/core/testing';
import { MovieService } from './movie.service';

// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('MovieService', () => {
  let service: MovieService;

  beforeEach(() => {
		TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(MovieService);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
