import { Department } from './department.model';

export class Worker {
    WorkerId: number
    Name: string
    Sallary: number
    EmploymentDate: Date = new Date()
    Department: Department
}
