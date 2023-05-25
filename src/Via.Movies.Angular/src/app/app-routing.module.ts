import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TopListComponent } from './top-list/top-list.component';

const routes: Routes = [
	{ path: '', component: HomeComponent },
  { path: 'top-list', component: TopListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
