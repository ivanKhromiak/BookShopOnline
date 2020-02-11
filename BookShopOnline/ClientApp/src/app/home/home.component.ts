import { Component, OnInit } from '@angular/core';
import { BookService } from '../services/book.service'
import { Book } from '../models/book'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.css'],
  providers: [BookService]
})
export class HomeComponent implements OnInit {
  
  changedBook: Book = new Book();
  public books: Book[];
  lookMode: boolean = true;
  
  constructor(private bookService: BookService) {}

  ngOnInit(){ 
    this.loadBooks();
   }

  loadBooks(){
    this.bookService.getBooks().subscribe((result: Book[]) => {
      this.books = result;
    }, error => console.error(error));
  }

  save() {
    if (this.changedBook.id == null) {
        this.bookService.createBook(this.changedBook)
            .subscribe((result: Book) => this.books.push(result));
    } else {
        this.bookService.updateBook(this.changedBook)
            .subscribe(result => {
                this.loadBooks();
            }, error => console.error(error));
    }
    this.cancel();
  }

  editBook(book: Book) {
      this.changedBook = book;
  }
  
  cancel() {
      this.changedBook = new Book();
      this.lookMode = true;
  }

  delete(book: Book) {
      this.bookService.deleteBook(book.id)
          .subscribe(data => this.loadBooks());
  }

  add() {
      this.cancel();
      this.lookMode = false;
  }
}
