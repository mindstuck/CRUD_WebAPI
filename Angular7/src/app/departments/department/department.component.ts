import { Component, OnInit, ViewChild } from '@angular/core';
import { DepartmentService } from 'src/app/shared/department.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MatSort, MatPaginator } from '@angular/material';


@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styles: []
})
export class DepartmentComponent implements OnInit {

  constructor(private service: DepartmentService,
    private toastr: ToastrService) { }
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.resetForm();
  }



  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formDataDep  = {
      Id: 0,
      DepartmentName: '',
      Location: '',
      Workers: []
    }
  }


  onSubmit(form: NgForm) {
    if (this.service.formDataDep.Id == 0)
      this.insertRecord(form);
    else {
      this.updateRecord(form);
    }
  } 

    insertRecord(form: NgForm) {
      this.service.postDepartment().subscribe(
        res => {
          this.resetForm(form);
          this.toastr.success("Успешно сохранено");
          this.service.getDepartmentsList();
        },
        err => {
          console.log(err);
        }
      )
    }
    updateRecord(form: NgForm) {
      this.service.putDepartment().subscribe(
        res => {
          this.resetForm(form);
          this.toastr.info("Успешно сохранено");
          this.service.getDepartmentsList();
        },
        err => {
          console.log(err);
        }
      )
    }
}
