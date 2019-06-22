import { Component, OnInit, ViewChild } from '@angular/core';
import { Department } from 'src/app/shared/department.model';
import { DepartmentService } from 'src/app/shared/department.service';
import { ToastrService } from 'ngx-toastr';
import { MatSort, MatPaginator, PageEvent } from '@angular/material';

@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styles: []
})
export class DepartmentsListComponent implements OnInit {

  constructor(private service: DepartmentService,
    private toastr: ToastrService) {  }
  displayedColumns: string[] = ['DepartmentName', 'Location', 'actions'];

  // public pageNumber: number = 1;
  // public Count: number = 10;
  // public pageEvent: PageEvent;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  ngOnInit() {
    this.setTableSettings();
    this.service.getDepartmentsList();
  }

  chooseForm(dep: Department) {

    this.service.formDataDep = Object.assign({},dep);
  }

  setTableSettings() {
    this.service.paginator = this.paginator;
    this.service.sort = this.sort;
  }

  onDelete(Id) {
    if (confirm("Удалить департамент?")) {
    this.service.deleteDepartment(Id)
    .subscribe(
      res => 
      {
        this.toastr.warning("Успешно удалено");
        this.service.getDepartmentsList();
      },
      err => 
      {
        console.log(err);
      })
    }
  }
}
