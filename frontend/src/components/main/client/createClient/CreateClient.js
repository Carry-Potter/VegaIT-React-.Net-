import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";

const CreateClient = () => {
  return (
    <div id="new-member" class="new-member-inner">
      <h2>Create new client</h2>
      <ul class="form">
        <li>
          <label>Client name:</label>
          <input type="text" class="in-text" />
        </li>
        <li>
          <label>Address:</label>
          <input type="text" class="in-text" />
        </li>
        <li>
          <label>City:</label>
          <input type="text" class="in-text" />
        </li>
        <li>
          <label>Zip/Postal code:</label>
          <input type="text" class="in-text" />
        </li>
        <li>
          <label>Country:</label>
          <select>
            <option>Select country</option>
          </select>
        </li>
      </ul>
      <div class="buttons">
        <div class="inner">
          <a href="javascript:;" class="btn green">
            Save
          </a>
        </div>
      </div>
    </div>
  );
};

export default CreateClient;
