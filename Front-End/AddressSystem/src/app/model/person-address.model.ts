import { Address } from './address.model';
import { Name } from './name.model';

export class PersonAddress {
  id?: string;
  address: Address;
  name: Name;

  constructor(
    address: Address = new Address(),
    name: Name = new Name()
  ) {
    this.address = address;
    this.name = name;
  }
}