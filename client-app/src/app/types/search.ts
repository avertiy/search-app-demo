export interface SearchRequest {
  query: string;
}

export interface SearchResponse {
  item: SearchResultItem[];
}

export interface SearchResultItem {
  title: string;
  searchEngine: string;
}
