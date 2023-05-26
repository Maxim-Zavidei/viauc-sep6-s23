import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TopListComponent } from './top-list/top-list.component';
import { MovieInfoPageComponent } from './movie-info-page/movie-info-page.component';

const routes: Routes = [
	{ path: '', component: HomeComponent },
  { path: 'top-list', component: TopListComponent },
  { path: 'movie-details/:id', component: MovieInfoPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
