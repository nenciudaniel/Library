export class Book {
    Id: string;
    Title: string;
    Description: string;
    CoverImageContent: string;
    CoverImageFileName: string;
    Authors: Author[];
}

export class Author{
    Id: string;
    FirstName: string;
    LastName: string;
}

export class Filters{
    CurrentPage: number;
    PageSize: number;
    SearchText?: string;
    SortColumn?: string;
    IsAscending?: boolean;
}

export class GridResult{
    Items: any[];
    Total: number;
}

export interface ConfirmationDialogData {
    textTranslateKey?: string;
    text?: string;
    cancelButtonTextTranslateKey?: string;
    confirmButtonTextTranslateKey?: string;
    titleTranslateKey?: string;
    icon?: string;
    confirmationType?: string;
  }
  