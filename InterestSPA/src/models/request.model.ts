import { Computation } from "./computation.model";

export class Request {
  id!: number;
  value!: number;

  computations!: Computation[];
}
