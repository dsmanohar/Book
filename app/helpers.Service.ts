export class Helper{
    constructor() { }
    public userLogged: any = null;  
    public movies: { imagePath: string; name: string; id: number, language: string }[] = [];
    public originalMovies = this.movies;
    public selectedMovie: string = "";
    public moviePath: string = "";

    public FilterdMovies: { path: string; name: string; id: number, language: string }[] = [];
    changeLanguage(language: string) {
        this.movies = this.originalMovies;
        if (language === "All")
            return;
        this.movies = this.movies.filter((data) => {
            return data.language == language; 
        })
    }
}