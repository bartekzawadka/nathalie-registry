export class KeyValue<T1, T2>{
  public key: T1;
  public value: T2;

  constructor(key: T1, value: T2){
    this.key = key;
    this.value = value;
  }
}
