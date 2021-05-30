import React, { useState } from "react";

const Generate = () => {
    const [amount, setAmount] = useState('');

    const onGenerateClick = () => {
        window.location = `/file/getpeoplecsv?amount=${amount}`;
        document.getElementById('amount').value = "";
        document.getElementById('download-msg').textContent = "Your CSV has been downloaded!";
    }
   
    return (
        <div>
            <div className="row">
             <div className='col-md-4'>
                <input type="text" id="amount" className='form-control-lg' placeholder='Enter # People' onChange={e => setAmount(e.target.value)} />
            </div>
                <div className='col-md-4'>
                    <button className='btn btn-primary btn-lg' onClick={onGenerateClick}>Generate</button>
             </div>
            </div>
            <span id="download-msg"> </span>
        </div>
    )
}

export default Generate;