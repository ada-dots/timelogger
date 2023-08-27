import React, { useState } from 'react';

export default function Example() {
    // The useState hook returns an array with two elements: the current state value and a function to update the state value
    const [count, setCount] = useState(0);

    // The count variable holds the current state value, and the setCount function is used to update the state value

    return (
        <div>
            <p>You clicked {count} times</p>
            <button onClick={() => setCount(count + 1)}>
                Click me
            </button>
        </div>
    );
}