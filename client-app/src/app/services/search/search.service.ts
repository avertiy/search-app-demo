import { Injectable } from '@angular/core';
import { SearchRequest, SearchResponse } from '../../types/search';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private apiUri = 'http://localhost:52160/search';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  Search(request: SearchRequest): Observable<SearchResponse> {
    return this.http
      .get<SearchResponse>(this.apiUri + `?text=${request.query}`)
      .pipe(
        tap((_) => console.log('fetched search data', _)),
        catchError(this.handleError<any>('fetch search data'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
