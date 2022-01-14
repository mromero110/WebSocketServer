package com.javasockets.server;

import org.json.JSONException;
import org.json.JSONObject;

/**
 *
 * @author ROSZONE
 */
public class DataMessage {

    public String From;
    public String To;
    public String Command;
    public String Data;

    public String toJson() {
        JSONObject json = new JSONObject();
        try {
            json.put("From", From);
            json.put("To", To);
            json.put("Command", Command);
            json.put("Data", Data);
        } catch (JSONException ex) {
            System.out.println("toJson" + " | " + ex.getMessage());
        }
        return json.toString();
    }

    public static DataMessage build(String from, String command) {
        DataMessage msg = new DataMessage();
        msg.From = from;
        msg.To = "";
        msg.Data = "";
        msg.Command = command;
        return msg;
    }

    public static DataMessage fromJson(String data) {
        DataMessage msg = null;
        try {
            JSONObject jobj = new JSONObject(data);
            msg = new DataMessage();
            msg.From = jobj.getString("From");
            msg.To = jobj.getString("To");
            msg.Data = jobj.getString("Data");
            msg.Command = jobj.getString("Command");

        } catch (JSONException ex) {
            System.out.println("fromJson" + " | " + data);
        }
        return msg;
    }
}
