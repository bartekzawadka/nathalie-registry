export class SelectableListItem<T> {
  public isSelected: boolean;
  public isEnabled = true;
  public item: T;

  constructor(item: T, isSelected = false, isEnabled = true){
    this.isSelected = isSelected;
    this.item = item;
    this.isEnabled = isEnabled;
  }
}
