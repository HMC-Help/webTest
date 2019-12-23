import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiCallServiceService {
  readonly rootUrl = '/api/';
  constructor(private http: HttpClient) { }

  getList<T>(url: string): Observable<T[]> {
    return this.http.get<T[]>(this.rootUrl + url);
  }

  getInfo<T>(url: string): Observable<T> {
    return this.http.get<T>(this.rootUrl + url);
  }

  getById<T>(url: string, id: number): Observable<T> {
    return this.http.get<T>(this.rootUrl + url + '/' + id);
  }

  UpdateDB<T>(url: string, content: Object): Observable<T> {
    return this.http.post<T>(this.rootUrl + url, content);
  }

  AddDB<T>(url: string, content: Object): Observable<T> {
    return this.http.put<T>(this.rootUrl + url, content);
  }

  DeleteDB<T>(url: string, id: number): Observable<T> {
    const params = new HttpParams().set('id', id.toString());
    return this.http.delete<T>(this.rootUrl + url, { params });
  }
}
