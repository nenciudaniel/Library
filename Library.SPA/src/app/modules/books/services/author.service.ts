import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIEndpoints } from 'src/app/core/endpoints';
import { Author } from 'src/app/core/models';

@Injectable({
  providedIn: 'root'
})

export class AuthorService {
  constructor(private _httpClient: HttpClient) { }

  add(author: Author){
    return this._httpClient.post(APIEndpoints.ADD_AUTHOR, author);
  }

  delete(id: string){
    let path = APIEndpoints.DELETE_AUTHOR.replace("{id}", id);
    return this._httpClient.delete(path);
  }

  getAllAuthors(): Observable<Author[]>{
    return this._httpClient.get<Author[]>(APIEndpoints.GET_ALL_AUTHORS);
  }

  update(author: Author){
    return this._httpClient.put(APIEndpoints.UPDATE_AUTHOR, author);
  }
}