import { Injectable } from '@angular/core';
import { Department } from './department.model';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource,MatSort, MatPaginator, PageEvent} from '@angular/material';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  formDataDep: Department;
  //formDataWor: Worker;

  // public pageNumber: number = 1;
  // public Count: number = 10;
  // public pageEvent: PageEvent;


  readonly rootURL = "http://localhost:56084/api";
  matList: MatTableDataSource<any>;
  paginator: any;
  sort: any;
  
  constructor(private http: HttpClient) {  }

  postDepartment() {
    return this.http.post(this.rootURL + '/Department',this.formDataDep);
  }

  putDepartment() {
    return this.http.put(this.rootURL + '/Department/' + this.formDataDep.Id,this.formDataDep);
  }

  getDepartmentsData (event?:PageEvent) {
    return this.http.get(this.rootURL + "/Department");
  }

  deleteDepartment(Id) {
    return this.http.delete(this.rootURL + '/Department/' + Id);
  }
  
  getDepartmentsList() {
    return this.getDepartmentsData().subscribe(
      data=> {

      let array = data as Department[];
      this.matList = new MatTableDataSource(array);

      this.matList.sort = this.sort;
      this.matList.paginator = this.paginator;

      console.log(this.matList.paginator);
      // this.Count = data.Count;
      // this.pageNumber = data.PageIndex;
    },
    err => {
      console.log(err);
    });
  }
  
}
