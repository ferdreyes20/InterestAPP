import { Computation } from "./computation.model";

export class Request {
  id!: number;
  name!: string;

  computations!: Computation[];
}
