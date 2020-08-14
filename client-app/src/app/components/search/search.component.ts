import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../services/search/search.service';
import { SearchRequest, SearchResponse } from '../../types/search';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  request: SearchRequest = {
    query: 'cats',
  };
  response: SearchResponse = null;

  constructor(private searchService: SearchService) {}

  ngOnInit(): void {}

  onSearch(): void {
    this.searchService
      .Search(this.request)
      .subscribe((response) => (this.response = response));
  }
}
