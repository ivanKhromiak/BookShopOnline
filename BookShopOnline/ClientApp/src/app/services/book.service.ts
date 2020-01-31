import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book'

@Injectable()
export class BookService{

    private _url: string = '/api/books';

    constructor(private http: HttpClient){ }

    getBooks() {
        return this.http.get(this._url);
    }

    createBook(book: Book) {
        return this.http.post<Book>(this._url, book);
    }

    updateBook(book: Book) {
  
        return this.http.put(this._url + '/' + book.id, book);
    }

    deleteBook(id: number) {
        return this.http.delete(this._url + '/' + id);
    }
}