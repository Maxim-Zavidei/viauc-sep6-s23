import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { MovieCardComponent } from './movie-card/movie-card.component';
import { UserModule } from './user/user.module';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { TopListComponent } from './top-list/top-list.component';
import { MovieInfoPageComponent } from './movie-info-page/movie-info-page.component';



@NgModule({
  declarations: [
    AppComponent,
		HomeComponent,
    NavComponent,
    MovieCardComponent,
    TopListComponent,
    MovieInfoPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    UserModule
  ],
  providers: [],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [AppComponent]
})
export class AppModule { }
