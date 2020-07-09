import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';

@Component({
  selector: 'app-link-form',
  templateUrl: './link-form.component.html',
  styleUrls: ['./link-form.component.css']
})
export class LinkFormComponent implements OnInit {

  formGroup: FormGroup;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  
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
      uri: ['', Validators.required],
      tags: [[]]
    });

    if (this.initialValue) {
      this.formGroup.patchValue(this.initialValue)
    }
  }

  create() {
    console.log(this.formGroup.value);
    console.log(this.formGroup.valid);
    if (this.formGroup.valid) {
      this.onSubmit.emit(this.formGroup.value);
    }
  }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our fruit
    if ((value || '').trim()) {
      this.formGroup.controls.tags.value.push(value.trim());
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(tag: string): void {
    const index = this.formGroup.controls.tags.value.indexOf(tag);

    if (index >= 0) {
      this.formGroup.controls.tags.value.splice(index, 1);
    }
  }
}
