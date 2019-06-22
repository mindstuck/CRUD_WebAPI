import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { DepartmentsListComponent } from './departments/departments-list/departments-list.component';
import { DepartmentComponent } from './departments/department/department.component';
import { DepartmentService } from './shared/department.service';
import { DepartmentsComponent } from "./departments/departments.component";
import { MatTabsModule } from "@angular/material/tabs";
import { MatTableModule} from '@angular/material/table';
import { MatPaginatorModule} from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import {MatButtonModule} from '@angular/material/button';
import { WorkerComponent } from './departments/worker/worker.component';
import { WorkersListComponent } from './departments/workers-list/workers-list.component';
import {MatFormFieldModule} from '@angular/material/form-field';



@NgModule({
  declarations: [
    AppComponent,
    DepartmentsComponent,
    DepartmentComponent,
    DepartmentsListComponent,
    WorkerComponent,
    WorkersListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatFormFieldModule
  ],
  providers: [DepartmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }