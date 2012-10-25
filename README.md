            //set the IP and port to send to
            var sendhl = new SendHl7("lis-s22104-9000", 52345);

            //create the HL7 message
            var codes = new List<string>();
            codes.Add("CMP");
            
            var co = new OrderMessage("mrn", "firstName", "lastName", "orderNumber00","DOB", "ward",Sex.U, codes);
            var hl = co.toHl7();

            //send the hl7 message
            sendhl.SendHL7(hl);