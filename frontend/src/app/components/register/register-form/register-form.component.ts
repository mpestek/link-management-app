import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

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
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    });

    if (this.initialValue) {
      this.formGroup.patchValue(this.initialValue)
    }
  }

  register() {
    if (this.formGroup.valid) {
      this.onSubmit.emit(this.formGroup.value);
    }
  }
}
