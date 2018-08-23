import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegistriesService {

  constructor(private http: HttpClient) { }

  getRegistries() {
    return new Promise<any>((resolve, reject) => {
      this.http.get<any>(environment.apiEndpoint+"/registries").subscribe(resolve, reject);
    });
  }
}
