import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service'
import { Book } from '../models/book'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [BookService]
})
export class HomeComponent implements OnInit {
  
  public books: Book[];
  
  constructor(private bookService: BookService) {}

  ngOnInit(){ this.loadBooks() }

  loadBooks(){
    this.bookService.getBooks().subscribe((result: Book[]) => {
      this.books = result;
    }, error => console.error(error));
  }
}
