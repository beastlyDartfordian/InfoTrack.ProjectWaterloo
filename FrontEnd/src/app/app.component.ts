import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  readonly title = 'Project Waterloo';
  readonly apiBaseUrl = 'https://localhost:7157/';

  searchTerm: string = '';
  searchUrl: string = '';

  pageRankings: any[] = [];

  constructor(private httpClient: HttpClient) { }

  getPageRanking(): void {
    if (!this.searchTerm) {
      return;
    }

    if (!this.searchUrl) {
      return;
    }

    this.get(`api/pageranking/${this.searchTerm}/${this.searchUrl}`).subscribe((response: any) => {
      this.pageRankings.push(response);

      const h = response;
    });
  }

  get(pathname: string): Observable<any> {
    const endpoint = this.apiBaseUrl + pathname;

    return new Observable<any>((observer) => {
      this.httpClient.get(endpoint).subscribe({
        next: (response) => {
          observer.next(response);
          observer.complete();
        },
        error: (error) => {
          observer.error(error);
        }
      });
    });
  }
}
