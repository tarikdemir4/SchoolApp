import { Component, ElementRef, ViewChild, viewChild } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClassRoomModel } from '../../../models/clas-room.model';
import { StudentModel } from '../../../models/student.model';
import { HttpService } from '../../../services/http.service';
import { FormsModule, NgForm } from '@angular/forms';
import { StudentPipe } from '../../../pipes/student.pipe';
import { FormValidateDirective } from 'form-validate-angular';
import { SwalService } from '../../../services/swal.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, StudentPipe, FormValidateDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  clasRooms: ClassRoomModel[] = [];
  students: StudentModel[] = [];

  @ViewChild("studentAddModalCloseBtn") studentAddModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  @ViewChild("addClassRoomCloseBtn") addClassRoomCloseBtn :ElementRef<HTMLButtonElement > | undefined;

  addStudentModel: StudentModel = new StudentModel();
  updateStudentModel: StudentModel = new StudentModel();
  addClassRoomModel:ClassRoomModel=new ClassRoomModel();
  


  selectedRoomId: string = "";
  search: string = "";
  constructor(
    private http: HttpService,
    private swal: SwalService
  ) {
    this.getAllClassRooms();
  }
  getAllClassRooms() {
    this.http.get("ClassRoom/GetAll", (res) => {
      this.clasRooms = res;

      if (this.clasRooms.length > 0) {
        this.getAllStudentsByClassRoomId(this.clasRooms[0].id);
      }
    })
  }

  getAllStudentsByClassRoomId(roomId: string) {
    this.selectedRoomId = roomId;

    this.http.get("Students/GetAllByClassRoomId?classRoomId=" + this.selectedRoomId, res => {
      this.students = res;

      this.students = this.students.map((val) => {
        const identityNumberPart1 = val.identityNumber.substring(0, 2);
        const identityNumberPart2 = val.identityNumber.substring(val.identityNumber.length - 6, 2);

        const newHashedIdentityNumber = identityNumberPart1 + "******" + identityNumberPart2;
        val.identityNumber = newHashedIdentityNumber;

        return val;
      })
    });
  }

  createStudent(form: NgForm) {
    if (form.valid) {
      if (this.addStudentModel.classRoomId === "0") {
        alert("You have choose a valid class room");
        return;
      }

      this.http.post("Students/Create", this.addStudentModel, (res) => {
        console.log(res);

        this.studentAddModalCloseBtn?.nativeElement.click();
        this.swal.callToast(res.message);
        this.getAllStudentsByClassRoomId (this.addStudentModel.classRoomId);
        this.addStudentModel=new StudentModel();
      });
    }
  }

  clearInputInValidClass(){
    const inputs=document.querySelectorAll(".form-control.is-invalid");
    for(let i in inputs){
      const el = inputs[i];
      el.classList.remove("is-invalid");
    }
  }


  clearAddClassRoomModel(){
    this.addClassRoomModel=new ClassRoomModel();
    this.clearInputInValidClass();
  }

  createClassRoom(form:NgForm){
    if(form.valid){
      this.http.post("ClassRoom/Create",this.addClassRoomModel, (res)=>{
        this.swal.callToast(res.message);
        this.addClassRoomCloseBtn?.nativeElement.click();
      })
    }
  }
}
