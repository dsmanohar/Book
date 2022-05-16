import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http'
import { Helper } from '../helpers.Service'
@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss'],
})
export class MoviesComponent implements OnInit {
  //get movies from services anduse serviece aray
  private movieArray: any = []
  constructor(
    private router: Router,
    private http: HttpClient,
    public helper: Helper,
  ) {}

  ngOnInit(): void {
    this.http
      .get('https://localhost:7230/api/Movies/GetMovies')
      .subscribe((data: any) => {
        for (var movie of data) {
          console.log(movie)
          if (movie.id == 1) movie['path'] = '../../assets/images/avengers.jpg'
          if (movie.id == 2) movie['path'] = '../../assets/images/avatar.jpg'
          if (movie.id == 4) movie['path'] = '../../assets/images/dhangal.jpg'
          if (movie.id == 5) movie['path'] = '../../assets/images/uri.jpg'
          if (movie.id == 6) movie['path'] = '../../assets/images/BN.jpg'
          if (movie.id == 7) movie['path'] = '../../assets/images/RRR.jpg'
          this.movieArray.push(movie)
        }
        this.helper.movies = this.movieArray
        this.helper.originalMovies = this.movieArray
      })
  }
  changeRoute(index: number) {
    this.router.navigate([this.helper.movies[index].id])
  }
}
