import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Routes , RouterModule} from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviecardComponent } from './moviecard/moviecard.component';
import { BookingComponent } from './booking/booking.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Helper } from './helpers.Service';
import { AdminComponent } from './admin/admin.component';
import { AddMovieComponent } from './admin/add-movie/add-movie.component';
import { DeletemovieComponent } from './admin/deletemovie/deletemovie.component';
import { TheaterComponent } from './admin/theater/theater.component';
import { DeleteTheaterComponent } from './admin/delete-theater/delete-theater.component';

const appRoutes: Routes = [
  { path: '', component: MoviesComponent },
  { path: 'signup', component: SignupComponent},
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent },
  { path: ':id', component: BookingComponent }

]
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MoviesComponent,
    MoviecardComponent,
    BookingComponent,
    LoginComponent,
    SignupComponent,
    AdminComponent,
    AddMovieComponent,
    DeletemovieComponent,
    TheaterComponent,
    DeleteTheaterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [Helper],
  bootstrap: [AppComponent]
})
export class AppModule { }
