====================================================================
Copyright
====================================================================
Checksum Verifier Utility
Copyright 2013 Chase (carnageX) <carnagex@outlook.com>
This work is free. You can redistribute it and/or modify it under the
terms of the Do What The Fuck You Want To Public License, Version 2,
as published by Sam Hocevar. See http://www.wtfpl.net/ for more details.

====================================================================
Warranty
====================================================================
/* This program is free software. It comes without any warranty, to
     * the extent permitted by applicable law. You can redistribute it
     * and/or modify it under the terms of the Do What The Fuck You Want
     * To Public License, Version 2, as published by Sam Hocevar. See
     * http://www.wtfpl.net/ for more details. */

====================================================================
Details & Usage
====================================================================
Built on .NET Framework 4.0

Supported Checksum Algorithms: 
	MD5
	SHA-1
	SHA-256
	SHA-384
	SHA-512
	CRC16
	CRC32

Supports 2 modes: 
	Single File (Text and File)
	Multiple File
	
You can generate hashes for either mode, or compare to a checksum provided to the program by the user. 

To use:
	1) Select an algorithm (default is MD5 - assumed this would be most used)
	2) Select a tab (mode) to use
	3) (Optional) If verifying a file's checksum, enter it in the "Checksum" field. 
	4) Browse for a file to generate
	5) Click the Compare button 
		Note: for large files it may take some time... be patient!
	6) The result will appear in the appropriate section in the tab's section.
		a) For Single File mode: the checksum generated for the file will appear in the "File Checksum" field.  If comparing to an entered Checksum, the result will display below the File Checksum field, noting if it is a match or mismatch.  The checksum generated from the file will also turn green for a match, and red for a mismatch. 
		
		b) For Multiple Files mode: The generated checksum(s) will appear in the list to the right of the Browse and Compare buttons for each file.  It will also note if there was a match or mismatch to the given Checksum (if one was given). 
		
====================================================================		
License	Content
====================================================================
DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
                    Version 2, December 2004 

 Copyright (C) 2004 Sam Hocevar <sam@hocevar.net> 

 Everyone is permitted to copy and distribute verbatim or modified 
 copies of this license document, and changing it is allowed as long 
 as the name is changed. 

            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
   TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION 

  0. You just DO WHAT THE FUCK YOU WANT TO.
  
====================================================================		
Changelog
====================================================================

Version 2.5.3
	* Added CRC16 hash computation

Version 2.5.2
	* Set project target to AnyCPU instead of x86 only
	* Setup TF and MF tabs to change the Compare button text depending on user-inputted hash textbox state

Version 2.5.1
	* Code fixes and refactoring
	* Additional source documentation added

Version 2.5.0
	* Fixed file handling to dispose of file handle when finished computing the hash
	* Added CRC32 hash computation 

Version 1.0.0
	* Initial Release 
