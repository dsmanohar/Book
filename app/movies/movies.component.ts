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
          this.movieArray.push(movie)
        }
        this.helper.movies = this.movieArray
        this.helper.originalMovies = this.movieArray
      })
  }
  changeRoute(index: number) { 
    this.helper.moviePath = this.helper.movies[index].imagePath
    this.helper.selectedMovie = this.helper.movies[index].name
    this.router.navigate([this.helper.movies[index].id])
  }
}
