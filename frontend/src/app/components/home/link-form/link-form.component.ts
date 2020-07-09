import { Component, OnInit, Output, Input, EventEmitter, ElementRef, ViewChild, OnDestroy } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ENTER, COMMA } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { Observable, Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-link-form',
  templateUrl: './link-form.component.html',
  styleUrls: ['./link-form.component.css']
})
export class LinkFormComponent implements OnInit, OnDestroy {

  formGroup: FormGroup;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  
  @Input() initialValue;
  @Input() suggestedTags$: Observable<string[]>;
  @Output() onSubmit = new EventEmitter<any>();
  @Output() uriChanged = new EventEmitter<any>();

  @ViewChild('tagInput') tagInput: ElementRef<HTMLInputElement>;
  tagCtrl = new FormControl();

  sub: Subscription;

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.setUpUriChangeSubscription();
  }

  setUpUriChangeSubscription() {
    this.sub = this.formGroup.controls.uri.valueChanges.pipe(
      debounceTime(500)
    ).subscribe(newValue => 
      this.uriChanged.emit(newValue)
    );
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

  selected(event: MatAutocompleteSelectedEvent): void {
    this.formGroup.controls.tags.value.push(event.option.viewValue);
    this.tagInput.nativeElement.value = '';
    this.tagCtrl.setValue(null);
  }

  ngOnDestroy(): void {
    this.sub && this.sub.unsubscribe();
  }
}
