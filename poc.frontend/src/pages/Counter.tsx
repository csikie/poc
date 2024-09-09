import { useState } from "react";
import { Button } from "@/components/ui/button";

function Counter() {
    const [count, setCount] = useState(0);

  return (
    <div className="flex flex-col m-auto">
        <h1>Counter</h1>
        <h2>{count}</h2>
        <div className="flex space-x-3">
          <Button disabled={count === 0} onClick={() => setCount(0)}>Reset</Button>
          <Button onClick={() => setCount(count + 1)}>Increment</Button>
          <Button onClick={() => setCount(count - 1)}>Decrement</Button>
        </div>
    </div>
  );
}

export default Counter;
