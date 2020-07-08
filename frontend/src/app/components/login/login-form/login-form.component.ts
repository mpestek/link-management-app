import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  formGroup: FormGroup;

  @Input() initialValue;
  @Output() onSubmit = new EventEmitter<any>();

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
      username:
       ['', Validators.required],
      password: ['', Validators.required]
    });

    if (this.initialValue) {
      this.formGroup.patchValue(this.initialValue)
    }
  }

  login() {
    if (this.formGroup.valid) {
      this.onSubmit.emit(this.formGroup.value);
    }
  }
}
