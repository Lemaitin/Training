import { Component } from '@angular/core';
import { DatePipe, formatDate } from '@angular/common';
import {FormControl} from '@angular/forms';
import { BehaviorSubject, combineLatest, map, tap } from 'rxjs';

interface Category {
  value: string;
  viewValue: string;
}
export interface UsersData {
  id: number;
  Category: string;
}

const USER_DATA = [
  {id: 1, "Title": "qwe", "Secret Name": "Vlados", "Secret Value": "MegaSecret", "URL": "www.sql-ex.ru", "Description": "MegaDiscription", "Expiration Date": "08.03.2023", Category: "Home", "Creation Time": "", "Last Modification Time": "", isSelected: false },
  {id: 2, "Title": "qwe", "Secret Name": "Vlados", "Secret Value": "MegaSecret", "URL": "www.sql-ex.ru", "Description": "MegaDiscription", "Expiration Date": "08.03.2023", Category: "Work", "Creation Time": "", "Last Modification Time": "", isSelected: false },
  {id: 3, "Title": "qwe", "Secret Name": "Vlados", "Secret Value": "MegaSecret", "URL": "www.sql-ex.ru", "Description": "MegaDiscription", "Expiration Date": "08.03.2023", Category: "Games", "Creation Time": "", "Last Modification Time": "", isSelected: false },
  {id: 4, "Title": "qwe", "Secret Name": "Vlados", "Secret Value": "MegaSecret", "URL": "www.sql-ex.ru", "Description": "MegaDiscription", "Expiration Date": "08.03.2023", Category: "Business", "Creation Time": "", "Last Modification Time": "", isSelected: false },
];

const COLUMNS_SCHEMA = [
  {
    key: 'isSelected',
    type: 'isSelected',
    label: ''
  },
  {
    key: "Title",
    type: "text",
    label: "Title"
  },
  {
    key: "Secret Name",
    type: "text",
    label: "Secret Name"
  },
  {
    key: "Secret Value",
    type: "text",
    label: "Secret Value"
  },
  {
    key: "URL",
    type: "text",
    label: "URL"
  },
  {
    key: "Description",
    type: "text",
    label: "Description"
  },
  {
    key: "Expiration Date",
    type: "date",
    label: "Expiration Date"
  },
  {
    key: "Category",
    type: "text",
    label: "Category"
  },
  {
    key: "Creation Time",
    type: "text",
    label: "Creation Time"
  },
  {
    key: "Last Modification Time",
    type: "text",
    label: "Last Modification Time"
  },
  {
    key: "isEdit",
    type: "isEdit",
    label: ""
  }
]

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [DatePipe]
})
export class AppComponent {
  columnsName = new FormControl();
  dropdownColumnNameList = ['Title', 'Secret Name', 'Secret Value', 'URL', 'Description', 'Expiration Date', 'Category', 'Creation Time', 'Last Modification Time'];
  
  selectedCategory: string | undefined;
  categories: Category[] = [
    {value: 'home', viewValue: 'Home'},
    {value: 'work', viewValue: 'Work'},
    {value: 'games', viewValue: 'Games'},
    {value: 'business', viewValue: 'Business'},
  ];
  currentDate = new Date();
  currentDateValue = formatDate(this.currentDate, 'dd MMM yyyy hh:mm a', 'en-US');
  title = 'SecretManager';
  displayedColumns: any[] = COLUMNS_SCHEMA.map((col) => col.key);
  dataSource: any = USER_DATA;
  columnsSchema: any = COLUMNS_SCHEMA;
  
  addRow() {
    const newRow = { id: Date.now(), "Title": '', "Secret Name": '', "Secret Value": '', "URL": '', "Description": '', "Expiration Date": '', "Category": '', "Creation Time": this.currentDateValue, "Last Modification Time": '', isEdit: true};
    this.dataSource = [...this.dataSource, newRow];
  }
  removeRow(id: number) {
    this.dataSource = this.dataSource.filter((u: any) => u.id !== id);
  }
  removeSelectedRows() {
    this.dataSource = this.dataSource.filter((u: any) => !u.isSelected);
  }
  update(selectedCategory: any){
    this.dataSource = this.dataSource.filter((u: UsersData) => u.Category.toLowerCase() == selectedCategory)
  }
}