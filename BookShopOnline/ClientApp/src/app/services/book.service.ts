import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BookService{

    private _url: string = '/api/books';

    constructor(private http: HttpClient){ }

    getBooks() {
        return this.http.get(this._url);
    }
}