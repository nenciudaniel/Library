import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIEndpoints } from 'src/app/core/endpoints';
import { Author, Book, Filters, GridResult } from 'src/app/core/models';
import { CommonService } from 'src/app/core/services/common.service';

@Injectable({
  providedIn: 'root'
})

export class BookService {
  constructor(
    private _commonService: CommonService,
    private _httpClient: HttpClient) { }

  add(book: Book){
    return this._httpClient.post(APIEndpoints.ADD_BOOK, book);
  }

  get(id: string): Observable<Book>{
    let path = APIEndpoints.GET_BOOK.replace("{id}", id);
    return this._httpClient.get<Book>(path);
  }

  delete(id: string){
    let path = APIEndpoints.DELETE_BOOK.replace("{id}", id);
    return this._httpClient.delete(path);
  }

  filter(filters: Filters): Observable<GridResult>{
    return this._httpClient.get<GridResult>(APIEndpoints.FILTER_BOOKS + this._commonService.modelToQueryParams(filters));
  }

  update(book: Book){
    return this._httpClient.put(APIEndpoints.UPDATE_BOOK, book);
  }
}