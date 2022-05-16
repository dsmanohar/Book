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

const appRoutes: Routes = [
  { path: '', component: MoviesComponent },
  { path: 'signup', component: SignupComponent},
  { path: 'login', component: LoginComponent },
  
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
